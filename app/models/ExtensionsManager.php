<?php
class ExtensionsManager extends MongoInterface {
    private function tri($a, $b) {
        $aArray = json_decode(json_encode($a), true);
        $bArray = json_decode(json_encode($b), true);

        return strcasecmp($aArray['ext'], $bArray['ext']);
    }

    private function searchRegex($id) {
        global $lang;

        return array_merge(
            $this->getCondContent('howtoopenme','extensions', 
                ['ext' =>  new \MongoDB\BSON\Regex(preg_quote($id), 'i')]
            ),
            $this->getCondContent('howtoopenme','extensions', 
                ['name' =>  new \MongoDB\BSON\Regex(preg_quote($id), 'i')]
            ),
            $this->getCondContent('howtoopenme','extensions', 
                ['name_'.$lang->getLanguage() =>  new \MongoDB\BSON\Regex(preg_quote($id), 'i')]
            )
        );
    }

    private function searchAlias($id) {
        return $this->getCondContent('howtoopenme','aliases', 
                ['alias' =>  new \MongoDB\BSON\Regex(preg_quote($id), 'i')]
            );
    }

    public function getAliases($id) {
        return $this->getCondContent('howtoopenme','aliases', 
                ['ext' =>  new \MongoDB\BSON\Regex(preg_quote($id), 'i')]
            );
    }

    public function search($id) {
        $retour = $this->searchRegex($id);

        foreach ($this->searchAlias($id) as $value) {
            $value = json_decode(json_encode($value), true);
            $retour = array_merge($retour, $this->searchRegex($value["ext"]));
        }

        $retour = array_unique($retour, SORT_REGULAR);

        uasort($retour, array('ExtensionsManager','tri'));

        return $retour;
    }
    
    public function get($id) {
        $content = $this->getCondContent('howtoopenme','extensions', 
                ['ext' =>  strtolower($id)]);
            
        if(count($content) == 0) { return $content; }

        return json_decode(json_encode(
            $content[0]
        ), true);
    }

    public function sortByDescViews() {
        $command = new MongoDB\Driver\Command([
            'aggregate' => 'extViews',
            'pipeline' => [
                ['$match' => ['date' => ['$gt' => (time() - 7 * 24 * 3600) ] ] ],
                //['$match' => ['ext' => 'png' ] ],
                ['$group' => ['_id' => '$ext', 'sum' => ['$sum' => '$viewCount']]],
                ['$sort' => ['sum' => -1]]
            ],
            'cursor' => new stdClass 
        ]);

        return $this->manager->executeCommand('howtoopenme', $command);
    }

    public function incViewCount($page) {
        $bulkUpdate = new MongoDB\Driver\BulkWrite();
        $filter = [   
            'date' => time() - (time() % (24 * 3600)),
            'ext' => $page
        ];

        $content = $filter;
        $content['viewCount'] = 0;

        // Insert if needed
        $bulkUpdate->update(
            $filter,
            ['$setOnInsert' => $content ],
            ['upsert' => true]);

        $bulkUpdate->update(
            $filter,
            ['$inc' => ['viewCount' => 1] ]);

        $this->manager->executeBulkWrite('howtoopenme.extViews', $bulkUpdate);
    }
}