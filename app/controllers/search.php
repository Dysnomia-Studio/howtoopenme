<?php
/**
 * Format URL: search?s=XXXXXXX
 *   s: terme recherché
 */

$s = (isset($_GET['s']))?$_GET['s']:'';
$s = htmlentities(htmlspecialchars($s));

if(strlen($s) < 3) { // On ne lance pas de recherche si le terme est trop petit
	$pageData['pageName'] = 'index.php';
	$pageData['error'] = TOO_SMALL_SEARCH;
} else {
	// Get data from extensions database
	$extMngr = new ExtensionsManager();
	$extensions = $extMngr->search($s);

	// Get data from softwares database
	$softMngr = new SoftwaresManager();
	$softwares = $softMngr->search($s);

	$resultCount = count($extensions) + count($softwares);
	if($resultCount == 0) {
		$pageData['pageName'] = 'index.php';
		$pageData['error'] = NO_RESULT_FOUND;
		
	} else if($resultCount == 1) {
		if(count($extensions) == 1) {
			$pageData['pageName'] = 'ext.php';
			$pageData['data'] = json_decode(json_encode($extensions[0]), true);

		} else {
			$pageData['pageName'] = 'soft.php';
			$pageData['data'] = json_decode(json_encode($softwares[0]), true);

		}

		include(DIR_CTRL.'view.php');
	} else {
		// Do nothing
	}
}