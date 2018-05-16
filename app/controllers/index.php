<?php
$em = new ExtensionsManager();
$extensions = array();

foreach ($em->sortByDescViews() as $key => $val) {
	$extensions[$key] = json_decode(json_encode($val), true);
}

$sm = new SoftwaresManager();
$softwares = array();

foreach ($sm->sortByDescViews() as $key => $val) {
	$softwares[$key] = json_decode(json_encode($val), true);
}