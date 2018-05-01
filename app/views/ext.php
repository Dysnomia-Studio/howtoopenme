<section class="corps center-corps corps-view">
	<h1 class="view-title1">.<?= $pageData['data']['ext'] ?></h1>
	<p class="view-title2" class="fullname"><?= $pageData['data']['name'] ?></p>
	<p><?php
		echo ALIASES.': ';
		$first = true;
		foreach ($pageData['aliases'] as $value) {
			if(!$first) { echo ', '; }

			$value = json_decode(json_encode($value), true);
			echo $value['alias'];

			$first = false;
		}
		?></p>
	<p><?= $pageData['data']['desc'] ?></p>

</section>
<section class="corps corps-ad">
	<script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
	<!-- Howtoopen.me - Responsive -->
	<ins class="adsbygoogle"
		 style="display:block"
		 data-ad-client="***REMOVED***"
		 data-ad-slot="***REMOVED***"
		 data-ad-format="auto"></ins>
	<script>
	(adsbygoogle = window.adsbygoogle || []).push({});
	</script>
</section>
<section class="corps corps-view">

	<table>
		<tr><th rowspan="2"><?= SOFTWARE ?></th><th rowspan="2"></th><th colspan="3"><?= POSSIBLE_ACTIONS ?></th><th rowspan="2"></th><th colspan="5"><?= OPERATING_SYSTEM ?><th rowspan="2"></th><th rowspan="2"><?= FREEWARE ?></th></tr>
		<tr><th><?= IMPORT ?></th><th><?= EXPORT ?></th><th><?= EXECUTE ?></th>
			<th>Windows</th><th>MacOS</th><th>GNU/Linux</th><th>Android</th><th>iOS</th></tr>
		<?php
		foreach ($pageData['data']['extAndSoftList'] as $extAndSoft) {
	
			echo '<tr>
				<td><a href="view?soft='.$extAndSoft['soft'].'">'.$extAndSoft['name'].'</a></td>
				<td></td>
				<td>'.drawStatus($extAndSoft['import']).'</td>
				<td>'.drawStatus($extAndSoft['export']).'</td>
				<td>'.drawStatus($extAndSoft['exec']).'</td>
				<td></td>
				<td>'.drawStatus($extAndSoft['windows']).'</td>
				<td>'.drawStatus($extAndSoft['macos']).'</td>
				<td>'.drawStatus($extAndSoft['linux']).'</td>
				<td>'.drawStatus($extAndSoft['android']).'</td>
				<td>'.drawStatus($extAndSoft['ios']).'</td>
				<td></td>
				<td>'.drawStatus($extAndSoft['free']).'</td>
			</tr>';
		}
		?>
	</table>
</section>