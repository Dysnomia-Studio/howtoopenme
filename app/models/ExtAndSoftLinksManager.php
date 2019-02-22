<?php
class ExtAndSoftLinksManager extends SQLInterface {
	public function searchByExt($id) {
		return $this->getCondContent('public."extAndSoft"', 
				['ext' =>  strtolower($id)]
			);
	}
	public function searchBySoft($id) {
		return $this->getCondContent('public."extAndSoft"', 
				['soft' =>  strtolower($id)]
			);
	}
}