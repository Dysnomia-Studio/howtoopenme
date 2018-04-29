<?php
include(DIR_VIEW.'menu.php');
?>
<section class="corps">
	<h1><?= $pageData['data']['ext'] ?></h1>
	<span class="fullname"><?= $pageData['data']['name'] ?></span>
	<p><?= $pageData['data']['desc'] ?></p>

	<table>
		<tr><th rowspan="2"><?= SOFTWARE ?></th><th colspan="4"><?= POSSIBLE_ACTIONS ?></th><th rowspan="2"><?= FREEWARE ?></th></tr>
		<tr><th><?= IMPORT ?></th><th><?= EXPORT ?></th><th><?= EXECUTE ?></th></tr>
		<?php
		foreach ($pageData['data']['extAndSoftList'] as $extAndSoft) {
	
			echo '<tr>
				<td><a href="view?soft='.$extAndSoft['soft'].'" target="_blank">'.$extAndSoft['name'].'</a></td>
				<td>'.drawCheckBox($extAndSoft['import']).'</td>
				<td>'.drawCheckBox($extAndSoft['export']).'</td>
				<td>'.drawCheckBox($extAndSoft['exec']).'</td>
				<td>'.drawCheckBox($extAndSoft['free']).'</td>
			</tr>';
		}
		?>
	</table>
</section>