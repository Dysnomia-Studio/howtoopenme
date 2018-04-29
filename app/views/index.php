<nav class="menu">
	<span class="menu-title"><a href="/">HowToOpen.me</a></span>
	<img class="menu-language" src="img/flags/fr.png">
</nav>

<section class="corps">
	<div class="index-search">
		<form class="search-bar" method="get" action="search">
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