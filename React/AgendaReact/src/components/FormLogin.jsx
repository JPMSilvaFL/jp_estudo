import {Button, Input} from "@mantine/core";
import style from "./Form.module.css";
import {useState} from "react";
import {validatePassword, validateUsername} from "../services/Validates.jsx";


export function ButtonForm({label, type}){
    return (
        <Button variant="outline" size="md" color="cyan" type={type}>{label}</Button>
    )
}
export function InputForm({placeholder, type,label, onHandleChange: onValueChange, error}){
    const [value, setValue] = useState("");
    const [errors, setErrors] = useState([]);

    const HandleChange = (e) =>{
        setValue(e.target.value);
        if(label){
            let handleError = [];
            if(error){
                handleError.push(error);
            }
            if(label === "Username")
                handleError = validateUsername(e.target.value);

            if(label === "Password")
                handleError = validatePassword(e.target.value)



            if(handleError.length === 0){
                setErrors([""]);
            }
            else{
                setErrors(handleError);
            }
        }

        onValueChange(e.target.value);
    }

    return(
        <Input.Wrapper label={label} error={
            errors.length > 0 ? (
                <>
                    {errors.map((err, i) => (
                        <div key={i}>{err}</div>
                    ))}
                </>
            ) : null
        }>
            <Input className={style.inputForm}
                   placeholder={placeholder}
                   type={type}
                   variant="filled"
                   color="cyan"
                   value={value}
                   label={label}
                   onChange={HandleChange}>
            </Input>
        </Input.Wrapper>
    )
}