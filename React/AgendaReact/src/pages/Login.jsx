import style from "../components/Form.module.css";
import {ButtonForm, InputForm} from "../components/FormLogin.jsx";
import React, {useState} from "react";
import {GlobalContext} from "../store/GlobalContext.jsx";
import { useNavigate } from "react-router-dom";
import RegisterModal from "../components/RegisterModal.jsx";


function Login() {
    const navigate = useNavigate();
    const {setAuthentication} = React.useContext(GlobalContext);
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const HandleSubmit = async (e) =>{
        e.preventDefault();

        try{
            const response = await fetch("http://localhost:5184/api/v1/login",{
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    username,
                    password
                })
            });
            const {data, errors } = await response.json();
            if(errors.length > 0 && errors){
                console.log(errors);
            }else{
                var token = data[0].jwtKey;
                setAuthentication(token);
                navigate("http://localhost:5173/", {replace: true});
            }
        }catch{
            console.log("Erro ao fazer login");
        }
    }

    return (
        <div className={style.containerForm}>
            <form className={style.form} onSubmit={HandleSubmit}>
                <InputForm placeholder="Username" onHandleChange={setUsername}/>
                <InputForm placeholder="Password" type="password" onHandleChange={setPassword}/>
                <ButtonForm type="submit" label="Login" className={style.buttonFormLogin}/>
                <p className={style.formRegister}><RegisterModal /></p>
                <p className={style.formForgot}>Esqueceu sua senha?</p>
            </form>
        </div>
    )
}
export default Login;