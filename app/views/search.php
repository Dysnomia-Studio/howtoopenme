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