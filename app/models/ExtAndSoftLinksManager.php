<?php
class ExtAndSoftLinksManager extends MongoInterface {
	public function searchByExt($id) {
		return $this->getCondContent('howtoopenme','extAndSoft', 
				['ext' =>  strtolower($id)]
			);
	}
	public function searchBySoft($id) {
		return $this->getCondContent('howtoopenme','extAndSoft', 
				['soft' =>  strtolower($id)]
			);
	}
}