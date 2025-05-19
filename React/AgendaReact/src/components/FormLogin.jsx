import {Button, Input} from "@mantine/core";
import style from "./Form.module.css";

export function ButtonForm({label}){
    return (
        <Button variant="outline" size="md" color="cyan">{label}</Button>
    )
}
export function InputForm({placeholder, type}){
    return(
        <Input className={style.inputForm} placeholder={placeholder} type={type} variant="filled" color="cyan"></Input>
    )
}