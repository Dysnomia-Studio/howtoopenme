<?php
include(DIR_VIEW.'menu.php');
?>
<section class="corps">
	<h1><?= $pageData['data']['name'] ?></h1>
	<p class="smallname"><?= $pageData['data']['smallname'] ?></p>
	<p class="website"><?= OFFICIAL_WEBSITE.': <a href="'.$pageData['data']['url'].'">'.$pageData['data']['url'].'</a>' ?></p>
	<p><?= $pageData['data']['desc'] ?></p>

	<table>
		<tr><th rowspan="2"><?= EXTENSION ?></th><th colspan="3"><?= POSSIBLE_ACTIONS ?></th><th rowspan="2"><?= FREEWARE ?></th></tr>
		<tr><th><?= READ ?></th><th><?= WRITE ?></th><th><?= EXECUTE ?></th></tr>
		<?php
		foreach ($pageData['data']['extAndSoftList'] as $extAndSoft) {
			$extAndSoft = json_decode(json_encode($extAndSoft), true);

			echo '<tr>
				<td>'.$extAndSoft['ext'].'</td>
				<td>'.$read.'</td>
				<td>'.$write.'</td>
				<td>'.$exec.'</td>
				<td>'.$extAndSoft['free'].'</td>
			</tr>';
		}
		?>
	</table>
</section>