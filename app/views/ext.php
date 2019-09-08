<section class="corps center-corps corps-view">
	<h1 class="view-title1">.<?= $pageData['data']['ext'] ?></h1>
	<p class="view-title2" class="fullname"><?= $pageData['data']['name'] ?></p>
	<?php
		if(isset($pageData['data']['MIMEType'])) {
			echo '<p class="view-title2" class="mimietype"><u>MIME:</u> '.$pageData['data']['MIMEType'].'</p>';
		}

		if(isset($pageData['data']['FileType'])) {
			echo '<p class="view-title2" class="mimietype"><u>'.FILETYPE.':</u>  '.$pageData['data']['FileType'].'</p>';
		}

		if(isset($pageData['aliases'])) {
			$first = true;
			$append = false;
			foreach ($pageData['aliases'] as $value) {
				if($first)  { echo '<p>'.ALIASES.': '; $append = true; }
				if(!$first) { echo ', '; }

				$value = json_decode(json_encode($value), true);
				echo '.'.$value['alias'];

				$first = false;
			}
			if($append) { echo '</p>'; }
		}
		?>
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
<?= ADBLOCKERS_TEXT ?>
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
	<table aria-describedby="Compatible Softwares">
		<tr>
			<th scope="col" rowspan="2"><?= SOFTWARE ?></th>
			<th scope="col" rowspan="2"></th>
			<th scope="col" colspan="3"><?= POSSIBLE_ACTIONS ?></th>
			<th scope="col" rowspan="2"></th>
			<th scope="col" colspan="5"><?= OPERATING_SYSTEM ?></th>
			<th scope="col" rowspan="2"></th>
			<th scope="col" rowspan="2"><?= FREEWARE ?></th>
		</tr>

		<tr>
			<th scope="col"><?= IMPORT ?></th>
			<th scope="col"><?= EXPORT ?></th>
			<th scope="col"><?= EXECUTE ?></th>
			<th scope="col">Windows</th>
			<th scope="col">MacOS</th>
			<th scope="col">GNU/Linux</th>
			<th scope="col">Android</th>
			<th scope="col">iOS</th>
		</tr>
		
		<?php
		foreach ($pageData['data']['extAndSoftList'] as $extAndSoft) {
	
			echo '<tr>
				<td><a href="/soft/'.$extAndSoft['soft'].'">'.$extAndSoft['name'].'</a></td>
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