<section class="corps">
	<div class="index-search">
		<form class="search-bar" method="get" action="search">
			<p class="index-text"><?= HOME_MSG ?></p>
			<input type="text" name="s" placeholder="<?= SEARCH_PLACEHOLDER ?>" value="<?php if(isset($s)) echo $s; ?>">
			<input type="submit" value="<?= SEARCH ?>">
			<?php
				if(isset($pageData['error'])) {
					echo '<p class="index-error">'.$pageData['error'].'</p>';
				}
			?>
		</form>
	</div>
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
<section class="corps center-corps corps-flex">
	<div class="corps-half">
		<h2 class="center-title"><?= TOP_EXT ?></h2>
		<ol>
			<li></li>
			<li></li>
			<li></li>
			<li></li>
			<li></li>
			<li></li>
			<li></li>
			<li></li>
			<li></li>
			<li></li>
		</ol>
	</div>
	<div class="corps-half">
		<h2 class="center-title"><?= TOP_SOFT ?></h2>
		<ol>
			<li></li>
			<li></li>
			<li></li>
			<li></li>
			<li></li>
			<li></li>
			<li></li>
			<li></li>
			<li></li>
			<li></li>
		</ol>
	</div>
</section>