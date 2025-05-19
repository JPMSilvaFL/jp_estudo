import {Button, Input} from "@mantine/core";
import style from "./Form.module.css";
import {useState} from "react";

export function ButtonForm({label, type}){
    return (
        <Button variant="outline" size="md" color="cyan" type={type}>{label}</Button>
    )
}
export function InputForm({placeholder, type, onHandleChange: onValueChange}){
    const [value, setValue] = useState("");

    const HandleChange = (e) =>{
        setValue(e.target.value);
        onValueChange(e.target.value);
    }

    return(
        <Input className={style.inputForm}
               placeholder={placeholder}
               type={type}
               variant="filled"
               color="cyan"
               value={value}
               onChange={HandleChange}>
        </Input>
    )
}