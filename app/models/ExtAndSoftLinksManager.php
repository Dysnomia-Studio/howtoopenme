<?php
class ExtAndSoftLinksManager extends SQLInterface {
	public function searchByExt($id) {
		return $this->getCondContent('extAndSoft',
				['ext' =>  strtolower($id)],
				0, 10000,
				'use DESC, free DESC, soft ASC'
			);
	}
	public function searchBySoft($id) {
		return $this->getCondContent('extAndSoft',
				['soft' =>  strtolower($id)],
				0, 10000,
				'use DESC, free DESC, ext ASC'
			);
	}
}