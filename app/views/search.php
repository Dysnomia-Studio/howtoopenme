<section class="corps center-corps">
	<h1><?= RESULTS_FOR_SEARCH.' "'.$s ?>":</h1>

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
			function loadedA() {
				if(window.getComputedStyle(document.getElementsByClassName('beforeResult')[0]).height.charAt(0) === '0') {
					document.getElementById('disclaimerMessage').style.display = 'block';
				} else {
					document.getElementById('disclaimerMessage').style.display = 'none';
				}
			}
			window.addEventListener('load', () => setTimeout(loadedA, 500));
			document.getElementsByClassName('beforeResult')[0].children[0].children[0].children[0].children[0].addEventListener('load', loadedA);
		</script>
	</div>
</section>
<section class="corps center-corps search-corps">
	<?php if(count($extensions) > 0) { ?>
		<h2><?= EXTENSIONS ?></h2>
		<ul>
		<?php
			foreach ($extensions as $ext) {
				$ext = json_decode(json_encode($ext), true);

				echo '<li><a href="/ext/'.$ext['ext'].'">'.$ext['ext'].'</a></li>';
			}
		?>
		</ul>
	<?php } ?>

	<?php if(count($softwares) > 0) { ?>
	<h2><?= SOFTWARES ?></h2>
	<ul>
	<?php
		foreach ($softwares as $soft) {
			$soft = json_decode(json_encode($soft), true);
			
			// Traduction
			if(isset($soft["name_".$lang->getLanguage()])) {
				$soft["name"] = $soft["name_".$lang->getLanguage()];
			}

			echo '<li><a href="/soft/'.$soft['smallname'].'">'.$soft['name'].'</a></li>';
		}
	?>
	</ul>
	<?php } ?>
</section>