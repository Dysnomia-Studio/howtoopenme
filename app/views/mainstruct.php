<?php 
$debut = round(microtime(true) * 1000);

$lang = new Language(); // Init Translation system
?>
<!DOCTYPE html>
<!-- 
	Code by Elanis
	Copyright 2018-<?= date('Y') ?> 
	Don't copy this without permission
	I hope this code is readable.
-->
<html>
	<head>
		<title>HowToOpen.Me</title>
		<meta charset="UTF-8">
		<!-- On prepare le charset , les mots clés , le fichier css et l'icone du site -->
		<meta name="keywords" content="">
		<meta name="description" content="" />
		<meta name="viewport" content="width=device-width, initial-scale=1">

		<link rel="shortcut icon" type="image/png" href="./img/favicon.png"/>
		<link rel="stylesheet" media="screen" type="text/css" title="Design" href="./lib/css/style.css"/>
		<link rel="stylesheet" media="screen" type="text/css" title="Design" href="./lib/graph/style.css"/>
	</head>
	<body>
		<?php
			if($pageData['readCache']) { // Read HTML
				readfile($pageData['cacheName']);
			} else { // Read PHP
				include_once(FILE_CONFIG);

				if(file_exists(DIR_VIEW.$pageData['pageName']) || file_exists(DIR_CTRL.$pageData['pageName'])) {
					if($pageData['writeCache']) {
						ob_start(); // ouverture du tampon
					}

					if(file_exists(DIR_CTRL.$pageData['pageName'])) {
						include(DIR_CTRL.$pageData['pageName']);
					}

					if(file_exists(DIR_VIEW.$pageData['pageName'])) {
						include(DIR_VIEW.$pageData['pageName']);
					} else {
						http_response_code(404);
						include_once(DIR_ERRORS.'404.html');
						die();
					}

					if($pageData['writeCache']) {
						$pageContent = ob_get_contents(); // copie du contenu du tampon dans une chaîne
						ob_end_clean(); // effacement du contenu du tampon et arrêt de son fonctionnement

						file_put_contents($pageData['cacheName'], $pageContent); // on écrit la chaîne précédemment récupérée ($pageContent) dans un fichier ($pageData['cacheName'])

						echo $pageContent;
					}
				} else {
					http_response_code(404);
					include_once(DIR_ERRORS.'404.html');
					die();
				}
			}
		?>
	</body>
	<!-- Page generated in <?= ($debut - round(microtime(true) * 1000)) ?> ms -->
</html>