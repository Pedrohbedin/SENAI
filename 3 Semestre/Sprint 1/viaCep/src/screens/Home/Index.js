import { BoxInput } from "../../components/BoxInput"
import { ContainerForm, ScrollForm } from "./style"

export const Home = () => {
    return (
        <>
            <ScrollForm>
                <ContainerForm>
                    <BoxInput
                    textLabel={'Informar CEP'}
                    placeholder={'Cep...'}
                    keyType="numeric"
                    maxLenght={9}/>
                </ContainerForm>
            </ScrollForm>
        </>
    )
}