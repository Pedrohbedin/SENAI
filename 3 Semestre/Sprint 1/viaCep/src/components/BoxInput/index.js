import { Input } from "../Input/Input"
import { Label } from "../Label"
import { FieldContent } from "./style"

export const BoxInput = ({
    fieldWidth = 100,
    editable = false,
    textLabel,
    placeholder,
    fildValue = null,
    onChangeText = null,
    keyType = 'default',
    maxLenght
}) => {
    return (
        <FieldContent>
            <Label />
            <Input
                editable={editable}
                placeholder={placeholder}
                fieldValue={fildValue}
                fieldWidth={fieldWidth}
                onChangeText={onChangeText}
                keyType={keyType}
                maxLenght={maxLenght} />
        </FieldContent>
    )
}