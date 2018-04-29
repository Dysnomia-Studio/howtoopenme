<?php
include(DIR_VIEW.'menu.php');
?>
<section>
	<h1><?= RESULTS_FOR_SEARCH.' "'.$s ?>":</h1>

	<h2><?= EXTENSIONS ?></h2>
	<ul>
	<?php
		foreach ($extensions as $ext) {
			$ext = json_decode(json_encode($ext), true);

			echo '<li><a href="view?ext='.$ext['ext'].'">'.$ext['ext'].'</a></li>';
		}
	?>
	</ul>

	<h2><?= SOFTWARES ?></h2>
	<ul>
	<?php
		foreach ($softwares as $soft) {
			$soft = json_decode(json_encode($soft), true);
			
			echo '<li><a href="view?soft='.$soft['smallname'].'">'.$soft['name'].'</a></li>';
		}
	?>
	</ul>
</section>