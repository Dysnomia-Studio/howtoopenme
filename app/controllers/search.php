<?php
/**
 * Format URL: search?s=XXXXXXX
 *   s: terme recherché
 */

$s = (isset($_GET['s']))?$_GET['s']:'';
$s = htmlentities(htmlspecialchars($s));
$s = str_replace("-", " ", $s); // On retire les tirets afin d'etendre la recherche

if(strlen($s) < 1) { // On ne lance pas de recherche si le terme est trop petit
	$pageData['pageName'] = 'index.php';
	$pageData['cacheName'] = DIR_CACHE.'search-small-search.html';
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
		$pageData['cacheName'] = DIR_CACHE.'search-no-result.html';
		$pageData['error'] = NO_RESULT_FOUND;
		
	} else if($resultCount == 1 && ($extensions[0]['ext'] === $s || $softwares[0]['smallname'] === $s)) {
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