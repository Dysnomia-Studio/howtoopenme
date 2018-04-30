<section class="corps center-corps corps-view">
	<h1 class="view-title1">.<?= $pageData['data']['ext'] ?></h1>
	<p class="view-title2" class="fullname"><?= $pageData['data']['name'] ?></p>
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
<section class="corps center-corps corps-view">

	<table>
		<tr><th rowspan="2"><?= SOFTWARE ?></th><th colspan="4"><?= POSSIBLE_ACTIONS ?></th><th rowspan="2"><?= FREEWARE ?></th></tr>
		<tr><th><?= IMPORT ?></th><th><?= EXPORT ?></th><th><?= EXECUTE ?></th></tr>
		<?php
		foreach ($pageData['data']['extAndSoftList'] as $extAndSoft) {
	
			echo '<tr>
				<td><a href="view?soft='.$extAndSoft['soft'].'" target="_blank">'.$extAndSoft['name'].'</a></td>
				<td>'.drawStatus($extAndSoft['import']).'</td>
				<td>'.drawStatus($extAndSoft['export']).'</td>
				<td>'.drawStatus($extAndSoft['exec']).'</td>
				<td>'.drawStatus($extAndSoft['free']).'</td>
			</tr>';
		}
		?>
	</table>
</section>