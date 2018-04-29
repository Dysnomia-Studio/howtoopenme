<?php
class ExtensionsManager extends MongoInterface {
	public function search($id) {
		return array_merge(
			$this->getCondContent('howtoopenme','extensions', 
				['ext' =>  new \MongoDB\BSON\Regex(preg_quote($id), 'i')]
			),
			$this->getCondContent('howtoopenme','extensions', 
				['name' =>  new \MongoDB\BSON\Regex(preg_quote($id), 'i')]
			)
		);
	}
	public function get($id) {
		return json_decode(json_encode(
			$this->getCondContent('howtoopenme','extensions', 
				['ext' =>  strtolower($id)]
			)[0]
		), true);
	}
}