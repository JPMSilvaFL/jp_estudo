import express from 'express';
const app = express();
import routes from './routes';
import * as path from 'path';
import viteExpress from 'vite-express';
app.use(express.urlencoded({ extended: true }));
app.use(express.json());
app.use(express.static(path.resolve(__dirname, 'public')));


app.use(routes);

viteExpress.listen(app, 3000, () => {
    console.log('Acessar http://localhost:3000');
    console.log('Servidor executando na porta 3000');
});
