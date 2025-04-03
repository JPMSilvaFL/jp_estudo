import express, { request, response} from 'express';
const router = express.Router();

router.get('/', (req:Request , res:Response) => {
        res.render('../frontend/index.html');
    });

export default router;