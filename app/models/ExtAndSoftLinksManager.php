<?php
class ExtAndSoftLinksManager extends SQLInterface {
	public function searchByExt($id) {
		return $this->getCondContent('extAndSoft', 
				['ext' =>  strtolower($id)]
			);
	}
	public function searchBySoft($id) {
		return $this->getCondContent('extAndSoft', 
				['soft' =>  strtolower($id)]
			);
	}
}