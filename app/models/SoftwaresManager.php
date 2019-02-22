<?php
class SoftwaresManager extends SQLInterface {
    private function tri($a, $b) {
        $aArray = json_decode(json_encode($a), true);
        $bArray = json_decode(json_encode($b), true);

        return strcasecmp($aArray['name'], $bArray['name']);
    }

    public function search($id) {
        global $lang;
        
        $retour = array_merge(
            $this->getILIKECondContent('public."softwares"', 
                ['smallname' =>  preg_quote($id)]
            ),
            $this->getILIKECondContent('public."softwares"', 
                ['name' =>  preg_quote($id)]
            ),
            $this->getILIKECondContent('public."softwares"', 
                ['name_'.$lang->getLanguage() =>  preg_quote($id)]
            )
        );

        $retour = array_unique($retour, SORT_REGULAR);
        uasort($retour, array('SoftwaresManager','tri'));

        return $retour;
    }

    public function get($id) {
        $content = $this->getCondContent('public."softwares"', 
                ['smallname' =>  strtolower($id)]
            );
            
        if(count($content) == 0) { return $content; }

        return json_decode(json_encode(
            $content[0]
        ), true);
    }

    public function sortByDescViews() {
        /*$command = new MongoDB\Driver\Command([
            'aggregate' => 'softViews',
            'pipeline' => [
                ['$match' => ['date' => ['$gt' => (time() - 7 * 24 * 3600) ] ] ],
                ['$group' => ['_id' => '$soft', 'sum' => ['$sum' => '$viewCount']]],
                ['$sort' => ['sum' => -1]]
            ],
            'cursor' => new stdClass 
        ]);

        return $this->manager->executeCommand('howtoopenme', $command);*/
        return [];
    }

    public function incViewCount($page) {
        /*$bulkUpdate = new MongoDB\Driver\BulkWrite();
        $filter = [   
            'date' => time() - (time() % (24 * 3600)),
            'soft' => $page
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

        $this->manager->executeBulkWrite('howtoopenme.softViews', $bulkUpdate);*/
    }
}