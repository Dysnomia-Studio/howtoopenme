<?php
class ExtensionsManager extends SQLInterface {
    private function tri($a, $b) {
        $aArray = json_decode(json_encode($a), true);
        $bArray = json_decode(json_encode($b), true);

        return strcasecmp($aArray['ext'], $bArray['ext']);
    }

    private function searchRegex($id) {
        global $lang;

        return $this->getILIKECondContent('extensions', 
                ['ext' => preg_quote($id)]
            );
    }

    private function searchAlias($id) {
        return $this->getILIKECondContent('aliases', 
                ['alias' => preg_quote($id)]
            );
    }

    public function getAliases($id) {
        return $this->getILIKECondContent('aliases', 
                ['ext' => preg_quote($id)]
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
        $content = $this->getCondContent('extensions', 
                ['ext' =>  strtolower($id)]);
            
        if(count($content) == 0) { return $content; }

        return json_decode(json_encode(
            $content[0]
        ), true);
    }

    public function sortByDescViews() {
        return $this->selectQuery('
            SELECT SUM("viewCount") as somme, ext
                FROM public."extViews"
                WHERE "date" >= :currDate
                GROUP BY ext
                ORDER BY somme DESC
                LIMIT 10'
            , [ 'currDate' => (time() - 7 * 24 * 3600) ]);
    }

    public function incViewCount($page) {
        $this->updateQuery('INSERT INTO public."extViews"(
            ext, "date", "viewCount")
            VALUES (:ext, :currDate, 1)
            ON CONFLICT (ext, "date") DO
            UPDATE SET "viewCount" = public."extViews"."viewCount" + 1;',
            [
                'ext' => $page,
                'currDate' => time() - (time() % (24 * 3600)),
            ]
        );
    }
}