import React, {useEffect, useState} from 'react';
import { Modal, Button } from '@mantine/core';
import {useDisclosure} from "@mantine/hooks";
import {InputForm} from "./FormLogin.jsx";

function RegisterModal() {
    const [opened, { open, close }] = useDisclosure(false);
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");
    const [fullName, setFullName] = useState("");
    const [email, setEmail] = useState("");
    const [phone, setPhone] = useState("");
    const [cpf, setCpf] = useState("");
    const [address, setAddress] = useState("");
    const [errors, setErrors] = useState([])


    const HandleSubmit = (e) =>{
        e.preventDefault();

    }
    useEffect(() => {
        console.log(confirmPassword);
        if(confirmPassword === password){
            setErrors([""]);
        }else{
            setErrors(["Passwords don't match"]);
        }
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [confirmPassword]);


    return (
        <>
            <Modal opened={opened} onClose={close} title="Register">
                <form onSubmit={HandleSubmit}>
                    <InputForm placeholder="Username" label="Username"
                               onHandleChange={(value) => {
                                   setUsername(value);
                               }}/>
                    <InputForm placeholder="Password" type="password" label="Password" onHandleChange={setPassword}/>
                    <InputForm placeholder="Confirm Password" type="password" label="Confirm Password" onHandleChange={setConfirmPassword}
                               error={errors.length > 0 ? errors[0] : null}/>
                    <InputForm placeholder="Full Name" label="Full Name" onHandleChange={setFullName}/>
                    <InputForm placeholder="Email" label="Email" onHandleChange={setEmail}/>
                    <InputForm placeholder="Phone" label="Phone" onHandleChange={setPhone}/>
                    <InputForm placeholder="CPF" label="A valid CPF" onHandleChange={setCpf}/>
                    <InputForm placeholder="Address" label="Address" onHandleChange={setAddress}/>
                    <Button variant="outline" size="md" color="cyan" type="submit">Register</Button>
                </form>
            </Modal>

            <p>Click
                <a style={{color: 'purple', cursor: 'pointer'}} onClick={open}> here </a>
                to register
            </p>
        </>
    );
}

export default RegisterModal