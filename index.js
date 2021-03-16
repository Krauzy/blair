const express = require('express');
const path = require('path');
const app = express();
const port = 8080;

app.use(express.static('public'));
app.use(express.urlencoded({
    extended: false
}));

var output = 'Compiled Sucessful!\n\n--runtime: 4.6s'

app.set('views', path.join(__dirname, 'views'));
app.engine('html', require('ejs').renderFile);
app.set('view engine', 'html');

app.get('/', (req, res) => {    
    res.cookie('output', output);
    res.render('index.html');
});

app.post('/compiler', (req, res) => {
    output = 'Error';
    console.log(decodeURI(req.body.edit + ''));
    res.redirect('/');
});

app.listen(port, () => {
    console.log(`App listening at http://localhost:${port}`);
});

// module.exports = app;