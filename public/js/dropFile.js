function dropHandler(event) {
	event.preventDefault();

	console.debug('File(s) dropped');
	console.debug(event.dataTransfer.files);

	if(event.dataTransfer.files.length < 1) { return; }
	let extension = event.dataTransfer.files[0].name.split('.');
	if(extension.length < 1) { return; }
	extension = extension[extension.length - 1];

	console.debug('Extension: ' + extension);

	window.location.href = "https://howtoopen.me/search?s=" + extension;
}

let timeout = -1;

function dragOverHandler(event) {
	event.preventDefault();

	console.debug('File(s) in drop zone');

	document.getElementById('drop-overlay').style.display = 'block';

	if(timeout >= 0) {
		clearTimeout(timeout);
	}

	timeout = setTimeout(() => {
		document.getElementById('drop-overlay').style.display = 'none';
		timeout = -1;
	}, 100);
}

window.addEventListener('load', () => {
	document.body.addEventListener('drop', dropHandler);
	document.body.addEventListener('dragover', dragOverHandler);
});