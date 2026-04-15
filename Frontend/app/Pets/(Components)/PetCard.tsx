import { url } from 'inspector';
import React from 'react'

interface Pet {
    name: string;
    image: {
        alt: string;
        url: string;
    };
    tag: string;
    age: number;
    gender: string;
    size: string;
    status: string;
    description: string;
}
type PetCardProps={
    
    Props:Pet
}

const PetCard = ({Props}:PetCardProps) => {
    return (
        <>
            <div
                className="group relative bg-surface-container-lowest rounded-lg overflow-hidden flex flex-col transition-all duration-300 hover:shadow-editorial-hover">
                <div className="relative h-80 overflow-hidden">
                    <img alt="Golden Retriever"
                        className="w-full h-full object-cover transition-transform duration-500 group-hover:scale-105"
                        data-alt={Props.image.alt}
                        src={Props.image.url} />
                    <div className="absolute top-4 left-4">
                        <span
                            className="bg-surface/90 backdrop-blur-md px-3 py-1 rounded-full text-[10px] font-extrabold uppercase tracking-widest shadow-sm font-headline">{Props.tag}</span>
                    </div>
                    <button
                        className="absolute bottom-4 right-4 bg-surface text-primary p-3 rounded-full shadow-lg opacity-0 group-hover:opacity-100 transition-opacity translate-y-4 group-hover:translate-y-0">
                        <span className="material-symbols-outlined">favorite</span>
                    </button>
                </div>
                <div className="p-8">
                    <div className="flex justify-between items-start mb-4">
                        <div>
                            <h3 className="text-2xl font-extrabold tracking-tight font-headline">{Props.name}</h3>
                            <p className="text-sm text-on-surface-variant font-medium">{`${Props.age} • ${Props.gender} • ${Props.size}`}</p>
                        </div>
                        <span
                            className="px-2 py-1 bg-secondary-fixed text-on-secondary-fixed text-[10px] font-black rounded uppercase font-headline">{Props.status}</span>
                    </div>
                    <p className="text-on-surface-variant text-sm line-clamp-2 mb-6">{Props.description}</p>
                    <button
                        className="w-full py-4 rounded-xl bg-primary text-on-primary font-bold text-sm hover:bg-primary-container transition-all flex items-center justify-center gap-2 group/btn">
                        View Profile
                        <span
                            className="material-symbols-outlined text-sm group-hover/btn:translate-x-1 transition-transform">arrow_forward</span>
                    </button>
                </div>
            </div>
        </>
    )
}

export default PetCard