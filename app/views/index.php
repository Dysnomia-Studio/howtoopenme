<section class="corps">
	<div class="index-search">
		<form class="search-bar" method="get" action="search">
			<p class="index-text"><?= HOME_MSG ?></p>
			<input type="search" name="s" placeholder="<?= SEARCH_PLACEHOLDER ?>" value="<?php if(isset($s)) { echo $s; } ?>">
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
<section class="corps center-corps corps-flex ranks-corps">
	<div class="corps-half">
		<h2 class="center-title"><?= TOP_EXT ?></h2>
		<ol>
			<?php
			if(!isset($extensions) || !is_array($extensions)) {
				$extensions = array();
			}

			for($i=0; $i<min(10, count($extensions)); $i++) {
				echo '<li><a href="https://howtoopen.me/ext/'.$extensions[$i]['ext'].'">.'.$extensions[$i]['ext'].'</a></li>';
			}
			?>
		</ol>
	</div>
	<div class="corps-half">
		<h2 class="center-title"><?= TOP_SOFT ?></h2>
		<ol>
			<?php
			if(!isset($softwares) || !is_array($softwares)) {
				$softwares = array();
			}
			
			for($i=0; $i<min(10, count($softwares)); $i++) {
				echo '<li><a href="https://howtoopen.me/soft/'.$softwares[$i]['soft'].'">'.$softwares[$i]['name'].'</a></li>';
			}
			?>
		</ol>
	</div>
</section>