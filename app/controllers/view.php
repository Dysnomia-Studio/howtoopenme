<?php
/**
 * Format URL: view?ext=XXX ou view?soft=XXXXXXX
 *   ext: extension voulue
 *   soft: logiciel voulu
 */

if(isset($_GET['ext'])) {
	$pageData['pageName'] = 'ext.php';

	// Get data from extensions database
	$extMngr = new ExtensionsManager();

	$s = (isset($_GET['ext']))?$_GET['ext']:'';
	$s = htmlentities(htmlspecialchars($s));
	
	$pageData['data'] = $extMngr->get($s);

} else if(isset($_GET['soft'])) {
	$pageData['pageName'] = 'soft.php';

	// Get data from extensions database
	$softMngr = new SoftwaresManager();

	$s = (isset($_GET['soft']))?$_GET['soft']:'';
	$s = htmlentities(htmlspecialchars($s));

	$pageData['data'] = $softMngr->get($s);

} else if(!isset($pageData['data'])) {
	http_response_code(404);
	$pageData['error'] = DIR_ERRORS.'404.html';
}

// Recuperation des liens logiciels/extensions
if(isset($pageData['data'])) {
	if(isset($pageData['data']['smallname'])) {
		$extSoftMgr = new ExtAndSoftLinksManager();
		$pageData['data']['extAndSoftList'] = $extSoftMgr->searchBySoft($pageData['data']['smallname']);
	} else {
		$extSoftMgr = new ExtAndSoftLinksManager();
		$pageData['data']['extAndSoftList'] = $extSoftMgr->searchByExt($pageData['data']['ext']);
	}

	// Traduction
	if(isset($pageData['data']["name_".$lang->getLanguage()])) {
		$pageData['data']["name"] = $pageData['data']["name_".$lang->getLanguage()];
	}

	if(isset($pageData['data']["desc_".$lang->getLanguage()])) {
		$pageData['data']["desc"] = $pageData['data']["desc_".$lang->getLanguage()];
	}

	// On traite les données
	foreach ($pageData['data']['extAndSoftList'] as $key => $extAndSoft) {
		$extAndSoft = json_decode(json_encode($extAndSoft), true);

		// Cas d'utilisations
		$extAndSoft['import'] = ($extAndSoft['use'] >= 4);
		$extAndSoft['export'] = ($extAndSoft['use'] >= 2 && $extAndSoft['use'] < 4) || $extAndSoft['use'] >= 6;
		$extAndSoft['exec'] = (($extAndSoft['use']%2) == 1);

		// Nom du logiciel
		if(isset($pageData['data']['ext'])) { // Si extension
			$softMngr = new SoftwaresManager();
			$software = $softMngr->get($extAndSoft['soft']);
			$extAndSoft['name'] = $software['name'];
		}

		$pageData['data']['extAndSoftList'][$key] = $extAndSoft;
	}
}

function drawStatus($value=0) {
	$retour = '<input type="checkbox"';

	if($value) {
		$retour .= ' checked';
	}
	$retour .= ' disabled>';
	
	return $retour;
}