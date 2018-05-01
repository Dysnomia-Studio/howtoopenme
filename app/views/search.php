<section class="corps center-corps">
	<h1><?= RESULTS_FOR_SEARCH.' "'.$s ?>":</h1>

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
<section class="corps center-corps search-corps">
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
			
			// Traduction
			if(isset($soft["name_".$lang->getLanguage()])) {
				$soft["name"] = $soft["name_".$lang->getLanguage()];
			}

			echo '<li><a href="view?soft='.$soft['smallname'].'">'.$soft['name'].'</a></li>';
		}
	?>
	</ul>
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