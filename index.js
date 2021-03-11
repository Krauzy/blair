const express = require('express');
const path = require('path');
const app = express();
const port = 8080;

app.use(express.static('public'));

app.set('views', path.join(__dirname, 'views'));
app.engine('html', require('ejs').renderFile);
app.set('view engine', 'html');

app.get('/', (req, res) => {    
    res.cookie('output', 'Compiled Sucessful!\n\n--runtime: 4.6s');
    res.render('index.html');
});


app.listen(port, () => {
    console.log(`App listening at http://localhost:${port}`);
});

// module.exports = app;