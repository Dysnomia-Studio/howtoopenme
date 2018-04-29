<section class="corps center-corps">
	<h1 class="view-title1"><?= $pageData['data']['name'] ?></h1>
	<p class="smallname view-title2"><?= $pageData['data']['smallname'] ?></p>
	<p class="view-website"><?= OFFICIAL_WEBSITE.': <a href="'.$pageData['data']['url'].'">'.$pageData['data']['url'].'</a>' ?></p>
	<p><?= $pageData['data']['desc'] ?></p>

	<table>
		<tr><th rowspan="2"><?= EXTENSION ?></th><th colspan="4"><?= POSSIBLE_ACTIONS ?></th></tr>
		<tr><th><?= IMPORT ?></th><th><?= EXPORT ?></th><th><?= EXECUTE ?></th></tr>
		<?php
		foreach ($pageData['data']['extAndSoftList'] as $extAndSoft) {
			echo '<tr>
				<td><a href="view?ext='.$extAndSoft['ext'].'" target="_blank">'.$extAndSoft['ext'].'</a></td>
				<td>'.drawCheckBox($extAndSoft['import']).'</td>
				<td>'.drawCheckBox($extAndSoft['export']).'</td>
				<td>'.drawCheckBox($extAndSoft['exec']).'</td>
			</tr>';
		}
		?>
	</table>
</section>