<?php
/**
 * Format URL: search?s=XXXXXXX
 *   s: terme recherché
 */

$s = (isset($_GET['s']))?$_GET['s']:'';
$s = htmlentities(htmlspecialchars($s));
$s = str_replace('-', ' ', $s); // On retire les tirets afin d'etendre la recherche
$s = str_replace('%', '', $s); // On retire les % par securite
$s = str_replace('_', '', $s); // On retire les _ par securite

$forceExt = false;
if(substr($s, 0, 1) === '.') {
	$forceExt = true;
	$s = substr($s, 1);
}

if(strlen($s) < 2 || strlen(str_replace(' ', '', $s)) < 2) { // On ne lance pas de recherche si le terme est trop petit
	$pageData['pageName'] = 'index.php';
	$pageData['cacheName'] = DIR_CACHE.'search-small-search.html';
	$pageData['error'] = TOO_SMALL_SEARCH;
} else {

	// Get data from extensions database
	$extMngr = new ExtensionsManager();
	$extensions = $extMngr->search($s);

	if($forceExt === false) {
		// Get data from softwares database
		$softMngr = new SoftwaresManager();
		$softwares = $softMngr->search($s);
	} else {
		$softwares = [];
	}

	$resultCount = count($extensions) + count($softwares);
	if($resultCount == 0) {
		$pageData['pageName'] = 'index.php';
		$pageData['cacheName'] = DIR_CACHE.'search-no-result.html';
		$pageData['error'] = NO_RESULT_FOUND;
		
	} else if($resultCount == 1 && (count($extensions) == 1 && $extensions[0]['ext'] === $s || count($softwares) == 1 && $softwares[0]['smallname'] === $s)) {
		if(count($extensions) == 1) {
			echo '<script>window.location.href="/ext/'.$extensions[0]['ext'].'"</script>';
		} else {
			echo '<script>window.location.href="/soft/'.$softwares[0]['smallname'].'"</script>';
		}

		include(DIR_CTRL.'view.php');
	} else {
		// Do nothing
	}
}