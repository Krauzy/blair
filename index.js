const path = require('path');
const Lexical = require('./src/test/Lexical');
const express = require('express');
const app = express();
const port = 8081;

app.use(express.static('public'));
app.use(express.urlencoded({
    extended: false
}));

var output = 'Compiled Sucessful!\n\n--runtime: 0.4s';

app.set('views', path.join(__dirname, 'views'));
app.engine('html', require('ejs').renderFile);
app.set('view engine', 'html');

app.get('/', (req, res) => {    
    res.cookie('output', output);
    res.render('index.html');
});

app.post('/compiler', (req, res) => {
    const code = decodeURI(req.body.edit + '');
    const lex = new Lexical(code);
    lex.execute();
    const tokens = lex.getTokens();
    console.log(tokens);
    const errors = lex.getErrors();
    output = '';
    errors.forEach((value, index) => {
        output += value.getMessage() + '\n';
    });
    if(output.length == 0)
        output = 'Compiled Sucessful!\n\n--runtime: 0.4s'
    res.cookie('input', code);
    res.redirect('/');
});

app.listen(port, () => {
    console.log(`App listening at http://localhost:${port}`);
});