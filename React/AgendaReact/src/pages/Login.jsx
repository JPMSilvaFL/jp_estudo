import style from "../components/Form.module.css";
import {ButtonForm, InputForm} from "../components/FormLogin.jsx";
import {Center, Stack} from "@mantine/core";

function Login() {
    return (
        <div className={style.containerForm}>
            <form className={style.form}>
                <InputForm placeholder="Username"/>
                <InputForm placeholder="Password" type="password"/>
                <ButtonForm label="Login" className={style.buttonFormLogin}/>
                <p className={style.formRegister}><a>Cadastre-se</a></p>
                <p className={style.formForgot}>Esqueceu sua senha?</p>
            </form>
        </div>
    )
}
export default Login;