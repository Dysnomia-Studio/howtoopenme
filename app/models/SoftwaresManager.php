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
            $this->getILIKECondContent('softwares',
                ['smallname' =>  preg_quote($id)]
            ),
            $this->getILIKECondContent('softwares',
                ['name' =>  preg_quote($id)]
            ),
            $this->getILIKECondContent('softwares',
                ['name_'.$lang->getLanguage() =>  preg_quote($id)]
            )
        );

        $retour = array_unique($retour, SORT_REGULAR);
        uasort($retour, array('SoftwaresManager','tri'));

        return $retour;
    }

    public function get($id) {
        $content = $this->getCondContent('softwares',
                ['smallname' =>  strtolower($id)]
            );
            
        if(count($content) == 0) { return $content; }

        return json_decode(json_encode(
            $content[0]
        ), true);
    }

    public function sortByDescViews() {
        return $this->selectQuery('
            SELECT *
            FROM (SELECT SUM("viewCount") as somme, soft
                FROM public."softViews"
                WHERE "date" >= :currDate
                GROUP BY soft
                ORDER BY somme DESC
                LIMIT 10) top
            INNER JOIN softwares ON softwares.smallname = top.soft'
            , [ 'currDate' => (time() - 7 * 24 * 3600) ]);
    }

    public function incViewCount($page) {
        $this->updateQuery('INSERT INTO public."softViews"(
            soft, "date", "viewCount")
            VALUES (:soft, :currDate, 1)
            ON CONFLICT (soft, "date") DO
            UPDATE SET "viewCount" = public."softViews"."viewCount" + 1;',
            [
                'soft' => $page,
                'currDate' => time() - (time() % (24 * 3600)),
            ]
        );
    }
}