import { Button , Input } from "@mantine/core";
import {Token_request} from "../hooks/api.jsx";
import useForm from "./../hooks/useForm.jsx";

function Login() {

    const username = useForm();
    const password = useForm();

    async function HandleSubmit(e) {
        e.preventDefault();

        if(username.validate() && password.validate()) {
            const {url, options} = Token_request({
                username: username.value,
                password: password.value
                }
            )

            const response = await fetch(url, options);
            const json = await response.json();
            const token = json.token;
            console.log(token);
        }

    }

    return (
        <div>
            <form onSubmit={HandleSubmit}>
                <Input name="username" placeholder="Username" type="text" {...username}/>
                <Input name="password" placeholder="Password" type="password" {...password}/>
                <Button>Login</Button>
            </form>
        </div>
    )
}
export default Login;