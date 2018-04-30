<?php
class ExtensionsManager extends MongoInterface {
	private function tri($a, $b) {
			$aArray = json_decode(json_encode($a), true);
			$bArray = json_decode(json_encode($b), true);

			return strcasecmp($aArray['ext'], $bArray['ext']);
	}

	public function search($id) {
		$retour = array_merge(
			$this->getCondContent('howtoopenme','extensions', 
				['ext' =>  new \MongoDB\BSON\Regex(preg_quote($id), 'i')]
			),
			$this->getCondContent('howtoopenme','extensions', 
				['name' =>  new \MongoDB\BSON\Regex(preg_quote($id), 'i')]
			)
		);

		$retour = array_unique($retour, SORT_REGULAR);

		uasort($retour, array('ExtensionsManager','tri'));

		return $retour;
	}
	
	public function get($id) {
		return json_decode(json_encode(
			$this->getCondContent('howtoopenme','extensions', 
				['ext' =>  strtolower($id)]
			)[0]
		), true);
	}
}