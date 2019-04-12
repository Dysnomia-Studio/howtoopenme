<section class="corps center-corps corps-view">
	<h1 class="view-title1"><?= $pageData['data']['name'] ?></h1>
	<p class="smallname view-title2"><?= $pageData['data']['smallname'] ?></p>
	<?php if($pageData['data']['url'] !== null) { ?>
	<p class="view-website"><?= OFFICIAL_WEBSITE.': <a href="'.$pageData['data']['url'].'" target="_blank">'.$pageData['data']['url'].'</a>' ?></p>
	<?php } ?>
	<p><?= $pageData['data']['desc'] ?></p>

</section>
<section class="corps corps-ad">
	<div class="beforeResult">
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

		<div id="disclaimerMessage" class="disclaimerMessage">
			Hey you !<br/>
			Can you disable you adblocker please ?<br/>
			This is our only way to finance this website, we promise we won't display more than one ad per page :)<br/>
			Thanks and have fun with our tool !
		</div>

		<script type="text/javascript">
			window.addEventListener('load', () => {
				if(window.getComputedStyle(document.getElementsByClassName('beforeResult')[0]).height.charAt(0) === '0') {
					document.getElementById('disclaimerMessage').style.display = 'block';
				}
			});
		</script>
	</div>
</section>
<section class="corps corps-view">

	<table>
		<tr><th rowspan="2"><?= EXTENSION ?></th><th colspan="3"><?= POSSIBLE_ACTIONS ?></th></tr>
		<tr><th><?= IMPORT ?></th><th><?= EXPORT ?></th><th><?= EXECUTE ?></th></tr>
		<?php
		foreach ($pageData['data']['extAndSoftList'] as $extAndSoft) {
			echo '<tr>
				<td><a href="/ext/'.$extAndSoft['ext'].'">'.$extAndSoft['ext'].'</a></td>
				<td>'.drawStatus($extAndSoft['import']).'</td>
				<td>'.drawStatus($extAndSoft['export']).'</td>
				<td>'.drawStatus($extAndSoft['exec']).'</td>
			</tr>';
		}
		?>
	</table>
</section>