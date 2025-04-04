import express from 'express'
import cors from 'cors'
const HOSTNAME = process.env.HOSTNAME || 'http://localhost'
const app = express()
app.get('/', (req, res) => {
    res.send('Bem-vindo!')
});
app.use(cors({
    origin: ['http://localhost:3000']
}));
app.use((req, res) => {
    res.status(404)
});
app.listen(3000, () => {
    console.log(`Servidor rodando com sucesso ${HOSTNAME}: 3000`)
});