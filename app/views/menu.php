	<nav class="menu">
		<span class="menu-title"><a href="/">HowToOpen.me</a></span>

		<?php
		if($pageData['pageName'] != "index.php") { ?>
			<form class="search-bar" method="get" action="/search">
				<input type="text" name="s" placeholder="<?= SEARCH_PLACEHOLDER ?>">
				<input type="submit" value="<?= SEARCH ?>">
			</form>
		<?php } ?>

		<form method="post" class="menu-language" id="language-form">
	        <div id="language-list"></div>
	        <input type="text" id="selected-language" name="selected-language">
	    </form>
		<script type="text/javascript" src="/js/iconselect/control/iconselect.js"></script>
		<script type="text/javascript" src="/js/iconselect/iscroll.js"></script>
		<script type="text/javascript" src="/js/language-list.js"></script>
	    <?php
	    if($lang->getLanguage() == 'en') { ?>
	    <script type="text/javascript">
			window.addEventListener('load', function() {
				changed--;
				iconSelect.setSelectedIndex(1);
			});
		</script>
		<?php } ?>
	</nav>