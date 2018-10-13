<?php
// Stats
if(isset($s) && count(explode("/", $s)) == 1) { // Disable subidirs
	if(isset($_GET['ext']) && !empty($_GET['ext'])) { // Ext
		$em = new ExtensionsManager();
		$em->incViewCount($s);
	} elseif(isset($_GET['soft']) && !empty($_GET['soft'])) { // Soft
		$sm = new SoftwaresManager();
		$sm->incViewCount($s);
	}
}