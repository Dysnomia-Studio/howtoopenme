<?php
class SoftwaresManager extends MongoInterface {
	private function tri($a, $b) {
			$aArray = json_decode(json_encode($a), true);
			$bArray = json_decode(json_encode($b), true);

			return strcasecmp($aArray['name'], $bArray['name']);
	}

	public function search($id) {
		$retour = array_merge(
			$this->getCondContent('howtoopenme','softwares', 
				['smallname' =>  new \MongoDB\BSON\Regex(preg_quote($id), 'i')]
			),
			$this->getCondContent('howtoopenme','softwares', 
				['name' =>  new \MongoDB\BSON\Regex(preg_quote($id), 'i')]
			)
		);

		$retour = array_unique($retour, SORT_REGULAR);
		uasort($retour, array('SoftwaresManager','tri'));

		return $retour;
	}
	
	public function get($id) {
		return json_decode(json_encode(
			$this->getCondContent('howtoopenme','softwares', 
				['smallname' =>  new \MongoDB\BSON\Regex('^'.preg_quote($id).'$', 'i')]
			)[0]
		), true);
	}
}