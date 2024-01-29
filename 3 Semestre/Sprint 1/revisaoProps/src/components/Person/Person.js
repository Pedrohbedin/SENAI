import {StyleSheet, Text, View} from 'react-native'

const Person = ({ name, age }) => {
    return ( 
        <View style={styles.container}>
            <Text style={styles.text}>Nome: {name}</Text>
            <Text style={styles.text}>Idade: {age}</Text>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        backgroundColor: 'black',
        margin: 5,
        padding: 10,
        borderRadius: 10
    },
    text: {
        color: 'white',
        fontSize: 15,
        fontWeight: 'bold'
    }
})

export default Person