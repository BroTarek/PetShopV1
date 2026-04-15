import React, { ReactNode } from 'react'


type PetGridProps={
    children:ReactNode
}
const PetGrid = ({children}:PetGridProps) => {
    return (
        <>
            <section className="flex-grow">
                {children}
            </section>
        </>
    )
}

export default PetGrid