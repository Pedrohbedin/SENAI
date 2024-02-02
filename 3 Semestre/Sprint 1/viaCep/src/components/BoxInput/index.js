import { Input } from "../Input/Input"
import { Label } from "../Label"
import { FieldContent } from "./style"

export const BoxInput = ({
    fieldWidth = 100,
    editable = false,
    textLabel,
    placeholder,
    fieldValue = null,
    onChangeText = null,
    keyType = 'default',
    maxLenght
}) => {
    return (
        <FieldContent fieldWidth={fieldWidth}>
            <Label 
            textLabel={textLabel}/>
            <Input
                editable={editable}
                placeholder={placeholder}
                keyType={keyType}
                maxLenght={maxLenght}
                fieldValue={fieldValue}
                onChangeText={onChangeText}
                 />
        </FieldContent>
    )
}