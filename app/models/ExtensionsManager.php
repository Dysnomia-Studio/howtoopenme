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
		return json_decode(json_encode(
			$this->getCondContent('howtoopenme','extensions', 
				['ext' =>  strtolower($id)]
			)[0]
		), true);
	}
}