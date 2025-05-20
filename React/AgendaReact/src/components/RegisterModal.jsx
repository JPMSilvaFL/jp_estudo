import React, {useState} from 'react';
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



    const HandleSubmit = (e) =>{
        e.preventDefault();


    }


    return (
        <>
            <Modal opened={opened} onClose={close} title="Register">
                <form onSubmit={HandleSubmit}>
                    <InputForm placeholder="Username" label="Username" onHandleChange={setUsername}/>
                    <InputForm placeholder="Password" type="password" label="Password" onHandleChange={setPassword}/>
                    <InputForm placeholder="Confirm Password" type="password" label="Confirm Password" onHandleChange={setConfirmPassword}/>
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