<?php
class SoftwaresManager extends MongoInterface {
	public function search($id) {
		return array_merge(
			$this->getCondContent('howtoopenme','softwares', 
				['smallname' =>  new \MongoDB\BSON\Regex(preg_quote($id), 'i')]
			),
			$this->getCondContent('howtoopenme','softwares', 
				['name' =>  new \MongoDB\BSON\Regex(preg_quote($id), 'i')]
			)
		);
	}
	public function get($id) {
		return json_decode(json_encode(
			$this->getCondContent('howtoopenme','softwares', 
				['smallname' =>  new \MongoDB\BSON\Regex('^'.preg_quote($id).'$', 'i')]
			)[0]
		), true);
	}
}