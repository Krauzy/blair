const express = require('express');
const path = require('path');
const app = express();
const port = 8080;

app.use(express.static('public'));

app.get('/', (request, response) => {
    response.sendFile(path.join(__dirname + '/public/index.html'));
});

app.listen(port, () => {
    console.log(`App listening at http://localhost:${port}`);
});

// module.exports = app;