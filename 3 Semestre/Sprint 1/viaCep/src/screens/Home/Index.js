import { useEffect, useState } from "react"
import { BoxInput } from "../../components/BoxInput"
import { ContainerForm, ScrollForm, ContainerLine } from "./style"

import axios from "axios"

export const Home = () => {
    const [cep, setCep] = useState('')
    const [endereco, setEndereco] = useState({});

    useEffect(() => {
        Buscar()
    }, [cep])

    const Buscar = async () => {
        if(cep.length != 8) {
            setEndereco({})
        } else {
            try {
                const promise = await axios.get(`https://brasilaberto.com/api/v1/zipcode/${cep}`);
                setEndereco(promise.data.result)
            } catch {
                setEndereco({})
            }
        }
    }

    return (
        <>
            <ScrollForm>
                <ContainerForm>
                    <BoxInput
                        onChangeText={setCep}
                        fieldValue={cep}
                        editable={true}
                        textLabel={'Informar CEP'}
                        placeholder={'Cep...'}
                        keyType="numeric"
                        maxLenght={9}
                         />
                    <BoxInput
                        fieldValue={endereco.street}
                        textLabel={'Logradouro'}
                        placeholder={'Logradouro...'}
                        keyType="numeric"
                        maxLenght={9} />
                    <BoxInput
                        fieldValue={endereco.district}
                        textLabel={'Bairro'}
                        placeholder={'Bairro...'}
                        keyType="numeric"
                        maxLenght={9} />
                    <BoxInput
                        fieldValue={endereco.city}
                        textLabel={'Cidade'}
                        placeholder={'Cidade...'}
                        keyType="numeric"
                        maxLenght={9} />
                </ContainerForm>
                <ContainerLine>
                    <BoxInput
                        fieldValue={endereco.state}
                        fieldWidth={66}
                        textLabel={'Estado'}
                        placeholder={'Estado...'}
                        keyType="numeric"
                        maxLenght={9} />
                    <BoxInput
                        fieldValue={endereco.stateShortname}
                        fieldWidth={25}
                        textLabel={'UF'}
                        placeholder={'UF...'}
                        keyType="numeric"
                        maxLenght={9} />
                </ContainerLine>
            </ScrollForm>
        </>
    )
}